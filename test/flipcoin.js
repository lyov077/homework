const { expect } = require("chai");

//const { expect } = require(chai);
describe("Test1", function(){
    it("Send right message", async function(){
        const Flip = await ethers.getContractFactory("FlipACoin") 
        const flip = await Flip.deploy(90);
        await flip.deployed();
        
        await flip.play(0);
        await flip.play(0);
        await flip.play(0);
        await flip.play(0);
        await flip.play(0);
        await flip.play(0);
        await flip.play(0);
        await flip.play(0);
        await flip.play(0);
        await flip.play(0);
    });

});