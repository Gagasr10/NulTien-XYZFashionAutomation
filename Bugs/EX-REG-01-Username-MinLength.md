ID: EX-REG-01-Username-MinLength
Title: Registration allows user creation with 1-character name
Environment: Production – https://xyzfashionstore.com/rs/customer/account/create/
Severity: High
Component: Registration Form
Reported by: Dragan Stojilkovic
Date: 2025-06-10
Testing Type: Exploratory Testing

Description:
During exploratory testing, it was observed that the registration form accepts and successfully creates a user with a 1-character name in the Ime (First Name) field. This is not aligned with basic validation practices, especially for an application intended solely for the Serbian market.

Steps to Reproduce:
Go to: https://xyzfashionstore.com/rs/customer/account/create/

In the field Ime (First Name) enter: J

In the field Prezime (Last Name) enter: Douglas

Email: wagas44949@adrewire.com

Password: JohnEng0

Submit the form

Expected Result:
User should not be allowed to register with a 1-letter name. A validation message should prompt for a longer name (e.g., minimum 2–3 characters), especially in alignment with typical Serbian naming standards.

Actual Result:
Registration is successful. User account is created with J as the first name.

Additional Notes:
Weak validation on user names may lead to spam or dummy accounts.

Impacts data integrity and potentially affects analytics or personalized communication features.

Suggest enforcing min length = 2 or 3 for first name field.

Attachments:
Screenshot manually saved in: /Screenshots/EX-REG-01_OneLetterName.png


