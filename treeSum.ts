interface TreeNode {
    val: number;
    left: TreeNode | null;
    right: TreeNode | null;
}

const treeSum = (root: TreeNode | null): number => {
    if (root === null) return 0;
    return root.val + treeSum(root.left) + treeSum(root.right);
};
