/* globals $ */

/* 

Create a function that takes an id or DOM element and:
  * If an id is provided, select the element
* Finds all elements with class `button` or `content` within the provided element
  * Change the content of all `.button` elements with "hide"
* When a `.button` is clicked:
  * Find the topmost `.content` element, that is before another `.button` and:
    * If the `.content` is visible:
      * Hide the `.content`
      * Change the content of the `.button` to "show"       
    * If the `.content` is hidden:
      * Show the `.content`
      * Change the content of the `.button` to "hide"
    * If there isn't a `.content` element **after the clicked `.button`** and **before other `.button`**, do nothing
* Throws if:
  * The provided DOM element is non-existant
  * The id is neither a string nor a DOM element
*/

function solve() {
  return function (selector) {
    var contentToChange;

    if (typeof selector === 'string') selector = document.getElementById(selector);
    else if (!(selector instanceof HTMLElement) || !document.contains(selector)) throw Error;

    Array.from(selector.getElementsByClassName('button'))
      .forEach(function (x) { x.innerHTML = 'hide' });

    selector.addEventListener("click", function (e) {
      if (e.target.className === 'button') {
        contentToChange = findNextContent(e.target);
      }
      if (contentToChange && contentToChange.style.display == '') {
        e.target.innerHTML = 'show';
        contentToChange.style.display = 'none';
      }
      else if (contentToChange && contentToChange.style.display == 'none') {
        e.target.innerHTML = 'hide';
        contentToChange.style.display = '';
      }
    })

    function findNextContent(currentElement) {
      var nextSibling = currentElement.nextElementSibling;

      while (true) {
        if (nextSibling == null || nextSibling.className === 'button') return null;
        else if (nextSibling.className === 'content') return nextSibling;
        else nextSibling = nextSibling.nextElementSibling;
      }
    }
  }
}

module.exports = solve;