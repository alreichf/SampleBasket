# sample Shopping Basket Implementation

## this project us built on .netcore 3.1 and is a console app

## This uses 3 main service classes

1. discountService - to apply discounts
2. shoppingbasketService - to add to the shopping basket
3. checkoutService - to compute basket details on clicking checkout

## it also contains some utils
1. discountEngine that gets a list of DiscountRules
2. a set of discount rules that can be applied to a basket
3. a set of domain/value objects for the products

## this also contains a test project that uses xunit

tests can be run from command line or visual studio as needed using: dotnet test

