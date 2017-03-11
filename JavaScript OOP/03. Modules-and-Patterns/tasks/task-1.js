/* Task Description */
/* 
* Create a module for a Telerik Academy course
  * The course has a title and presentations
    * Each presentation also has a title
    * There is a homework for each presentation
  * There is a set of students listed for the course
    * Each student has firstname, lastname and an ID
      * IDs must be unique integer numbers which are at least 1
  * Each student can submit a homework for each presentation in the course
  * Create method init
    * Accepts a string - course title
    * Accepts an array of strings - presentation titles
    * Throws if there is an invalid title
      * Titles do not start or end with spaces
      * Titles do not have consecutive spaces
      * Titles have at least one character
    * Throws if there are no presentations
  * Create method addStudent which lists a student for the course
    * Accepts a string in the format 'Firstname Lastname'
    * Throws if any of the names are not valid
      * Names start with an upper case letter
      * All other symbols in the name (if any) are lowercase letters
    * Generates a unique student ID and returns it
  * Create method getAllStudents that returns an array of students in the format:
    * {firstname: 'string', lastname: 'string', id: StudentID}
  * Create method submitHomework
    * Accepts studentID and homeworkID
      * homeworkID 1 is for the first presentation
      * homeworkID 2 is for the second one
      * ...
    * Throws if any of the IDs are invalid
  * Create method pushExamResults
    * Accepts an array of items in the format {StudentID: ..., Score: ...}
      * StudentIDs which are not listed get 0 points
    * Throw if there is an invalid StudentID
    * Throw if same StudentID is given more than once ( he tried to cheat (: )
    * Throw if Score is not a number
  * Create method getTopStudents which returns an array of the top 10 performing students
    * Array must be sorted from best to worst
    * If there are less than 10, return them all
    * The final score that is used to calculate the top performing students is done as follows:
      * 75% of the exam result
      * 25% the submitted homework (count of submitted homeworks / count of all homeworks) for the course
*/

function solve() {
  var Course = {
    courseTitle: '',
    presentations: [],
    students: [],

    init: function (title, presentations) {
      validateTitle(title);
      validateTitle(presentations);
      this.courseTitle = title;
      presentations.forEach((x, i) => this.presentations.push({ title: x, id: i + 1 }))

      function validateTitle(title) {
        if (Array.isArray(title) && title.length) title.forEach(x => validateTitle(x));
        else if (title.match(/^\s+|\s+$|\s{2,}|^$/ig)) throw 'Invalid Title';
      }

    },
    addStudent: function (name) {
      let names = name.split(' ');
      validateNames(names);
      let id = this.students.length + 1;

      this.students.push({
        firstname: names[0],
        lastname: names[1],
        id: id,
        homeworks: [],

      });

      function validateNames(names) {
        if (names.length !== 2) throw 'Number of names wrong';
        names.forEach(name => {
          if (!name.match(/([A-Z][a-z]*)/g)) throw 'Invalid Name';
        })
      }

      return id;
    },
    getAllStudents: function () {
      let allStudents = [];
      this.students.forEach(x =>
        allStudents.push({ firstname: x.firstname, lastname: x.lastname, id: x.id }));
        console.log(allStudents);
        return allStudents;
    },
    submitHomework: function (studentID, homeworkID) {
      validateID(studentID, this.students.length);
      validateID(homeworkID, this.presentations.length);
      this.students[studentID -1].homeworks.push(homeworkID);

      function validateID(id, limit) {
        
        if (id > limit || id < 1 || id !== (id | 0)) throw 'Invalid ID';
      }
    },
    pushExamResults: function (results) {
    },
    getTopStudents: function () {
    }
  };

  // var test = Object.create(Course);
  // test.init('Adasd Adasd', ['First Adsd']);
  // var id = test.addStudent('Pesho Pesho');
  // test.submitHomework(id, 1);
  // test.getAllStudents();
  return Course;
}
// solve()

module.exports = solve;
