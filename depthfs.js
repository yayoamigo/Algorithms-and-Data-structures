const depthFS= (root) => {
    if(root === null) return [];
    const leftNodes = depthFS(root.left);
    const rightNodes = depthFS(root.right);
    return [root.value,...leftNodes,...rightNodes]
}