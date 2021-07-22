//SPDX-License-Identifier: Unlicense
import "hardhat/console.sol";
pragma solidity ^0.8.6;
contract FlipACoin{
    uint index;
    constructor (uint _index){
        index = _index;
    }
    function confirm() private view returns (uint) {
        return block.timestamp % 2;
} 
    function play(uint _symbol)public payable{
        uint a = confirm();
        //require(address(this).balance > (msg.value * index)/100);
        if(a == _symbol){
            payable(msg.sender).transfer(msg.value*(100+index)/100);   
            console.log("You win", _symbol);
        }
        else{
            console.log("You lose", _symbol);
        }

    }
    

}