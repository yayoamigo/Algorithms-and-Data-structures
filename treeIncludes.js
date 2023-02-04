const treeIncludes = (root, target) => {
    if(root === null) return false;
    if(root.val === target) return true;
    return treeIncludes(root.left, target) || treeIncludes(root.right, target)
}