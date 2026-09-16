// let num: number = 10;
// let ages: number[] = [1, 2, 3];
// tuples
// let ageName: [number, string] = [28, 'samir'];


// Destructuring
// const user = {
//     address: "Bangladesh",
//     name: {
//         firstName: "sadaf",
//         middleName: "Hossain",
//         lastName: "samir",
//     },
//     contactNo: "0199929292",
// }
// const { address: contactNo, name: { firstName } } = user;

// array destructuring 
// array Destructuring

// const myFriends = ["joy", "sadaf", "fahim", "ikram", "khan"];

// const [bestFriend, bro, rest] = myFriends;
//enum
enum Color { 
  Red = 1,
    Green = 2,
    Blue = 4
};
let colorName: string = Color[2];

console.log(colorName);
