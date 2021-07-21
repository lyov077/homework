//SPDX-License-Identifier: Unlicense
pragma solidity ^0.8.6;
contract Number{
    int number;
    constructor(int _number){
        number = _number;
    }
    
    function getNumber() public view returns(int){
        return number;
    }
    
    function setNumber(int _number) public {
        number = _number;
    }
    
    function doubleNumber(uint _gorcakic) public { 
        number = number ** _gorcakic;
    }

}