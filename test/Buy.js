const { expect } = require("chai");
const { ethers } = require("hardhat");

describe("Buy", function () {
  it("Should return the new greeting once it's changed", async function () {
    const accounts = await ethers.getSigners();
    
    const TestToken = await ethers.getContractFactory("TestToken");
    const Buy = await ethers.getContractFactory("Buy");

    const token = await TestToken.deploy(accounts[0].address);
    await token.deployed();

    const buy = await Buy.deploy(token.address);
    await buy.deployed();
    
    
    const ts = await token.totalSupply();
    expect(await token.balanceOf(accounts[0].address)).to.equal("1000000000000000000000");//totalSupply check
    console.log("1");

    const balance = await token.balanceOf(accounts[0].address);
    expect(await token.balanceOf(accounts[0].address)).to.equal("1000000000000000000000");//balanceOf check
    console.log("2");
    
    /*const tx = await token.connect(accounts[0]).transfer(buy.address, ethers.utils.parseEther("1"));
    expect(await token.balanceOf(buy.address)).to.equal("1000000000000000000");//buy address check
    expect(await token.balanceOf(accounts[0].address)).to.equal("999000000000000000000");//main address check
    console.log("3");*/
    
    const bt = await buy.buyToken();
    await token.allowance();
    expect(await token.balanceOf(accounts[0].address)).to.equal("150000000");
  });
});
