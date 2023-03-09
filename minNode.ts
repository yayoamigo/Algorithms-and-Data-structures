interface Node {
    val: number;
    left: Node | null;
    right: Node | null;
};



const treeMinValue = (node: Node | null): number => {
    if (node === null) return Infinity;
    const leftMin = treeMinValue(node.left);
    const rightMin = treeMinValue(node.right);
    return Math.min(node.val, leftMin, rightMin);
}

