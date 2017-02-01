/* Task description */
/*
	Write a function that finds all the prime numbers in a range
		1) it should return the prime numbers in an array
		2) it must throw an Error if any on the range params is not convertible to `Number`
		3) it must throw an Error if any of the range params is missing
*/

function solve() {
	return function findPrimes(start, end) {
		let result = [];

		if (arguments.length < 2) throw new Error('Param is missing');
		else if (isNaN(+start) || isNaN(+end)) throw new Error('Param not convertible to number');

		for (let num = +start; num <= +end; num++) {
			if (isPrime(num)) result.push(num);
		}

		return result;

		function isPrime(number) {
			var maxDivisor = Math.sqrt(number),
				isPrime = true,
				currDivisor;

			if (number < 2) return false;

			for (currDivisor = 2; currDivisor <= maxDivisor; currDivisor++) {
				if (!(number % currDivisor)) {isPrime = false; break;}
			}

			return isPrime;
		}
	}
}

module.exports = solve;
