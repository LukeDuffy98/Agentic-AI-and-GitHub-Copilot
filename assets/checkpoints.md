# Lab Checkpoints

Use this file to compare your progress with the expected lab state.

## Checkpoint 1: Before code changes

Run:

```powershell
cd app
dotnet test
```

Expected result:

- 3 tests pass
- 2 tests are skipped

## Checkpoint 2: After Part 3

After you remove the skip from `FormatPackingSlip_ReturnsOneLinePerItem` and implement `FormatPackingSlip`, run:

```powershell
dotnet test
```

Expected result:

- 4 tests pass
- 1 test is skipped

## Checkpoint 3: After Part 4

After you remove the skip from `CalculateDiscount_GivesTenPercentDiscountToLargeLoyaltyOrders` and fix the bug, run:

```powershell
dotnet test
```

Expected result:

- all 5 tests pass

## Checkpoint 4: After Part 5

After the refactor, run:

```powershell
dotnet test
```

Expected result:

- all 5 tests still pass
