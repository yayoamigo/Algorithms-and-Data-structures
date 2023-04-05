const bestSum = (targetSum: number, numbers: number[], memo: {}): number[] | null => {
    if (targetSum in memo) return memo[targetSum];
    if (targetSum === 0) return [];
    if (targetSum < 0) return null;
    let shortestCombination: number[] | null = null;
    for (let num of numbers) {
        const remainder = targetSum - num;
        const remainderResult = bestSum(remainder, numbers, memo);
        if (remainderResult !== null) {
            const combination = [...remainderResult, num];
            if (shortestCombination === null || combination.length < shortestCombination.length) {
                shortestCombination = combination;
            }
        }
    }
    memo[targetSum] = shortestCombination;
    return shortestCombination;
};