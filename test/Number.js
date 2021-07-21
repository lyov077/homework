const { expect } = require("chai");

//const { expect } = require(chai);
describe("Test1", function(){
    it("Should **2", async function(){
        const Number = await ethers.getContractFactory("Number") 
        const number = await Number.deploy(5);
        await number.deployed();
        let msg = await number.getNumber();
        expect(msg).to.equal(5);
        await number.setNumber(7)
        expect(await number.getNumber()).to.equal(7);
        await number.doubleNumber(3);
        expect(await number.getNumber()).to.equal(7**3);
    });

});

