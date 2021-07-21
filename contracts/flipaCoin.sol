//SPDX-License-Identifier: Unlicense
import "hardhat/console.sol";
pragma solidity ^0.8.6;
contract FlipACoin{
    int side;
    constructor (){
        
    }
    function confirm() public pure returns(int){
         return 0;
    }
    
    function play(string memory _betAmount, int _symbol)public view{
        int a = confirm();
        if (a == _symbol) {
            console.log("You win ", _betAmount);   
        } else {
            console.log("You lose", _betAmount);
        }
    }
    

}