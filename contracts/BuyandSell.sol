//SPDX-License-Identifier: Unlicense

pragma solidity ^0.8.6;

import "@openzeppelin/contracts/token/ERC20/IERC20.sol";

contract Buy {
    IERC20 private token;
    uint256 public price;
    address public owner;
    
    constructor(address _token) {
        token = IERC20(_token);
        price = 1;
        owner = msg.sender;
    
    }

    function buyToken() external payable {
        require(msg.value > 0, "You need ETH");//stugi vor kanchoxy 0-ic avela uzum
        require(token.balanceOf(address(this)) >= msg.value * price, "Buy::Have not enough balance");//stugi vor reservuma aveli shat ka uzuma kanchox
        token.transfer(msg.sender, msg.value * price);

    }
    
    function sellToken(uint256 _amount) public{
        require(_amount > 0, "You need sell >0 token");//stugi vor kanchoxy 0 avela uzum caxi   
        uint256 allowance = token.allowance(msg.sender, address(this));   // kanchoxy tuyltvutyuna talis kontractin
        require(allowance >= _amount, "Check the token allowence");
        token.transferFrom(msg.sender, address(this), _amount);//kanchoxy pox e uxarkum kontractin
        payable(msg.sender).transfer(_amount);//owner uxarkuma 
    
    }

    function withdraw(uint256 _amount) external {
        
        require(msg.sender == owner,"Only owner can call this function.");
        require(address(this).balance >= _amount * price, "Buy::Have not enough balance");
        payable(msg.sender).transfer(_amount); 
    }
}
        
        
    