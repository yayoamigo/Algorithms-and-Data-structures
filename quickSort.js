function qs(arr, left = 0, right= arr.length - 1){

    if(left < right){
    
    let pIndex = Partition(arr, left , right);
    
    qs(arr, left, pIndex - 1);
    qs(arr, pIndex + 1, right);
    
    }
    return arr;
    };
    
    function Partition(arr, left , right){
    let random = Math.floor(Math.random() * right);
    
    if(random >= left ){
    [arr[random],arr[right]]=[arr[right],arr[random]]
    }
    
    let pivot = right;
    let j = left;
    let i = left - 1;
    while(j<=pivot){
    if ( arr[j]< arr[pivot] ) {
    i++;
    [arr[i],arr[j]] = [arr[j],arr[i]];
    j++
    } else {
    j++;
    }
    }
    i++;
    [arr[i],arr[pivot]] = [arr[pivot],arr[i]] ;
    return i;
    };
    
    
    let array = [1,26,7,6,2,9,4]
    console.log(qs(array))
   
    