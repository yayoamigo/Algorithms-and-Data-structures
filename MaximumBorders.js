function main(input) {
    let inputLines = input.split("\n");
    let t = parseInt(inputLines[0]);
    let currentLine = 1;
    for (let i = 0; i < t; i++) {
        let [n, m] = inputLines[currentLine++].split(" ").map(x => parseInt(x));
        let matrix = inputLines.slice(currentLine, currentLine + n);
        currentLine += n;
        let maxBorder = 0;
        for (let row of matrix) {
            let rowBorder = 0;
            for (let cell of row) {
                if (cell === "#") {
                    rowBorder++;
                } else {
                    maxBorder = Math.max(maxBorder, rowBorder);
                    rowBorder = 0;
                }
            }
            maxBorder = Math.max(maxBorder, rowBorder);
        }
        for (let j = 0; j < m; j++) {
            let colBorder = 0;
            for (let k = 0; k < n; k++) {
                if (matrix[k][j] === "#") {
                    colBorder++;
                } else {
                    maxBorder = Math.max(maxBorder, colBorder);
                    colBorder = 0;
                }
            }
            maxBorder = Math.max(maxBorder, colBorder);
        }
        console.log(maxBorder);
    }
}
