const maxpathSum = (root) => {
    if ( root === null ) return -Infinity;
    if( root.left === null && root.right === null ) return root.val;
    return root.val + Math.max( maxpathSum(root.left), maxpathSum(root.right) );
}