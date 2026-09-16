"use strict";
let num = 10;
let ages = [1, 2, 3];
//tuples
let ageName = [28, 'samir'];
//Destructuring
const user = {
    address: "Bangladesh",
    name: {
        firstName: "sadaf",
        middleName: "Hossain",
        lastName: "samir",
    },
    contactNo: "0199929292",
};
const { address: contactNo, name: { firstName } } = user;
console.log(user.address);
