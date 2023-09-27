using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text.Encodings.Web;
using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authorization;

namespace ApiLib.Auth;

public class XUserInfoAuthenticationHandler(
	 IOptionsMonitor<AuthenticationSchemeOptions> options,
	 ILoggerFactory logger,
	 UrlEncoder encoder,
	 ISystemClock clock) : AuthenticationHandler<AuthenticationSchemeOptions>(options, logger, encoder, clock)
{

	public const string SchemeName = "X-Userinfo";
	internal const string RoleType = "roles";

	protected override Task<AuthenticateResult> HandleAuthenticateAsync()
	{
		if (Context
				.GetEndpoint()?
				.Metadata.OfType<AllowAnonymousAttribute>()
				.Any() is null or true)
			return Task.FromResult(AuthenticateResult.NoResult());

		string xUserInfo = Request.Headers[SchemeName]!;

		if (string.IsNullOrEmpty(xUserInfo))
			return Task.FromResult(AuthenticateResult.Fail($"{SchemeName} header not found"));


		var payload = JwtPayload.Base64UrlDeserialize(xUserInfo) ?? throw new ArgumentException(null, "payload");

		ClaimsIdentity identity = new(
										claims: payload.Claims,
										authenticationType: SchemeName,
										nameType: "name",
										roleType: RoleType
						);

		AuthenticationTicket ticket = new(
								principal: new ClaimsPrincipal(identity),
								properties: new AuthenticationProperties(),
								authenticationScheme: SchemeName
				);


		return Task.FromResult(AuthenticateResult.Success(ticket));
	}

	//--------------------
}
