const { expect } = require("chai");

describe("Greeter", function () {
  it("Should return the new greeting once it's changed", async function () {
    const Greeter = await ethers.getContractFactory("Greeter");//подключается к контракту, создаёт contractFactory
    const greeter = await Greeter.deploy("Hello, world!");//deploy , создаёт контракт
    await greeter.deployed();//promise contract

    let msg = await greeter.greet();
    console.log("🚀 ~ file: sample-test.js ~ line 10 ~ msg", msg);

    expect(await msg).to.equal("Hello, world!");

    const setGreetingTx = await greeter.setGreeting("Hola, mundo!");
    //console.log("🚀 ~ file: sample-test.js ~ line 15 ~ setGreetingTx", setGreetingTx);
    const bal = ethers.provider.getBalance(greeter.address);
    //console.log("🚀 ~ file: sample-test.js ~ line 16 ~ bal", bal);
    // wait until the transaction is mined
    await setGreetingTx.wait();

    expect(await greeter.greet()).to.equal("Hola, mundo!");

  });
});
