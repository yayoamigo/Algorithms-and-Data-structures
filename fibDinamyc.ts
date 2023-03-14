const fib = ({ n, memo }: { n: number; memo: object; }): number => {
    if (n in memo) return memo[n];
    if (n <= 2) return 1;
    memo[n] = fib({ n: n - 1, memo }) + fib({ n: n - 2, memo });
    return memo[n];
}