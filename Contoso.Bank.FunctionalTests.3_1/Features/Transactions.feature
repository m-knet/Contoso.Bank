Feature: Transactions
	In order to avoid silly mistakes
	As a math idiot
	I *want* to be told the **sum** of ***two*** numbers

Link to a feature: [Calculator](Contoso.Bank.FunctionalTests/Features/Calculator.feature)
***Further read***: **[Learn more about how to generate Living Documentation](https://docs.specflow.org/projects/specflow-livingdoc/en/latest/LivingDocGenerator/Generating-Documentation.html)**

@transactions
Scenario: Get transactions
	Given a client without authentication
	When transactions are required
	Then status code should be 200

@transactions
Scenario: Add transaction
	Given a client without authentication
	When a new transaction is sent
	Then status code should be 405