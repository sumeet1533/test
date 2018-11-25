USE aspnetdb

UPDATE 
	aspnet_Membership
SET
	Password = KnownPassword.Password
   ,PasswordFormat = KnownPassword.PasswordFormat
   ,PasswordSalt = KnownPassword.PasswordSalt
FROM
(
	SELECT
		u.UserId
	   ,Password
	   ,PasswordFormat
	   ,PasswordSalt
	FROM
		aspnet_Membership m
	JOIN aspnet_Users u
		ON u.UserId = m.UserId
	WHERE 
		u.UserName = 'developer'
) KnownPassword
WHERE
	aspnet_Membership.UserId != KnownPassword.UserId