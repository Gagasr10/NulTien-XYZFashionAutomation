Bug Report
ID: TC16-InvalidStreet-Accepted
Title: Invalid street name accepted for valid city/postal code combination, user proceeds to payment
Environment: Production – https://xyzfashionstore.com/rs/checkout
Severity: High
Component: Shipping Form Validation
Reported by: Dragan Stojilkovic
Date: 2025-06-10

Description:
The checkout form does not properly validate the existence of the entered street address. During test case TC16, the user enters a nonexistent street ("Bulevar Milutina Milankovica 7") for a valid city ("Ruma") and postal code ("22400"). Despite the incorrect address, the application allows the user to proceed to the payment page, which may cause delivery issues or order rejection later in the process.

Steps to Reproduce:
Log in with valid credentials

Navigate to: Muškarci > Odeća > Majice

Select a product (e.g., Armani Majica), choose a size (e.g., L), and add to cart

Proceed to checkout

In the shipping form, enter:

City: Ruma

Postal Code: 22400

Street Address: Bulevar Milutina Milankovica 7 (nonexistent in Ruma)

Phone: +381621234555

Click 'Sledeće' to proceed

Expected Result:
Validation should fail with a clear error message indicating the street does not exist for the selected city/postal code.
User should not be allowed to continue to the payment page.

Actual Result:
User is redirected to the payment page (/checkout/#payment) even though the provided street does not match the selected location.

Additional Notes:
This could result in failed deliveries, customer dissatisfaction, and logistics overhead.

It weakens data validation and opens risk for invalid orders.

No warning message or frontend validation was triggered.

Screenshot is located in the Screenshots folder under the test execution directory.

