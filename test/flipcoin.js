const { expect } = require("chai");

//const { expect } = require(chai);
describe("Test1", function(){
    it("Send right message", async function(){
        const Flip = await ethers.getContractFactory("FlipACoin") 
        const flip = await Flip.deploy();
        await flip.deployed();
        
        await flip.play("1000", 0);
        await flip.play("1000", 1);
    });

});