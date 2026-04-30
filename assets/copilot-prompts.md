# Copilot Prompt Pack

Use these prompts when the README tells you to ask Copilot for help.

## Understand the project

```text
@workspace Describe this project in simple language. Tell me what each main folder is for and which file I should read first as a beginner.
```

## Explain the main code file

```text
#editor Explain this file for a beginner. What does each method do, and which method is intentionally unfinished?
```

## Explain the tests

```text
#editor Explain these tests in plain English. Which tests already pass, and which tests are skipped on purpose for the lab?
```

## Implement the missing method

```text
#selection Implement this method so it returns a packing slip string with a title and numbered lines for each item. Keep the output deterministic and handle null input.
```

## Investigate the discount bug

```text
I have a failing test named CalculateDiscount_GivesTenPercentDiscountToLargeLoyaltyOrders. Look at the current CalculateDiscount method and suggest the smallest code change needed to make the test pass.
```

## Refactor safely

```text
#selection Refactor this method to improve readability without changing behavior. Keep it beginner-friendly and avoid unnecessary complexity.
```

## MCP tool-use prompt

```text
Use the available tools to find the method that calculates discounts in this lab, explain how it works, and tell me the safest place to change the discount rule.
```
