/* Task Description */
/* 
	Write a function that sums an array of numbers:
		numbers must be always of type Number
		returns `null` if the array is empty
		throws Error if the parameter is not passed (undefined)
		throws if any of the elements is not convertible to Number	

*/

function solve() {
	return function sum(numbers) {
		let sum = 0;

		if (numbers == undefined) throw new Error('Argument not passed');
		if (numbers.length === 0) return null;

		numbers.forEach(function (element) {
			if (isNaN(+element)) throw new Error('An Element is not convertable to number');
			else sum += +element;
		});

		return sum;
	}
}
module.exports = solve;
