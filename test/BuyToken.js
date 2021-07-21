const { expect } = require("chai");
const { ethers } = require("hardhat");
describe("Buy", function () {
    it("Buy functions test", async function () {
        const Buy = await ethers.getContractFactory("Buy");
        const accounts = await ethers.getSigners();
        const buy = await Buy.deploy(accounts[0].address);
        await buy.deployed();
        console.log(buy.balanceOf(accounts[0].address));
        const bt = await buy.buyToken();
        console.log(bt);
        console.log(buy.balanceOf(accounts[1].address))
    
    });
});
