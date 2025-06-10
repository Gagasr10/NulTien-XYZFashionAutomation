Bug Report
ID: TC13-FilterColor-Teget-Inconsistency
Title: Inconsistent product display when filtering by color "Teget" (navy)
Environment: Production – https://xyzfashionstore.com/rs/muskarci/odeca/majice/
Severity: Medium
Component: Product Filters
Reported by: Dragan Stojilkovic
Date: 2025-06-09

Description:
When filtering men's t-shirts (Muškarci > Odeća > Majice) by color "Teget", not all displayed items conform to the expected color. Additionally, some results are not t-shirts at all (e.g., a wallet is shown in the list).

Steps to Reproduce:
Navigate to: https://xyzfashionstore.com/rs/muskarci/odeca/majice/

Click on Boja (Color) filter.

Select Teget from the available color options.

Observe the displayed products.

 Expected Result:
All returned products should clearly represent the color "Teget" (navy).

Only t-shirts should be listed under the "Majice" (T-Shirts) category.

 Actual Result:
Several items are not purely “Teget”; they appear grayish or have mixed/undefined patterns.

A wallet is included in the results, which is not a t-shirt.

Additional Notes:
This may affect user trust and reduce filter usability.

Visual inconsistencies impact the user’s ability to make accurate product selections.

Screenshot is located in the Screenshots folder under the test execution directory.


