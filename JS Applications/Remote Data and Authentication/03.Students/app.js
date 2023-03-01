    window.addEventListener('load', GetAllStudent);
    document.querySelector('#form').addEventListener('submit', CreateStudent);

    function LoadStudents(students) {
        const tbody = document.querySelector('tbody');
        
        tbody.innerHTML = "";

        students.forEach(s => {
            const tr = document.createElement('tr');

            const thFirstName = document.createElement('th');
            thFirstName.textContent = s.firstName;

            const thLastName = document.createElement('th');
            thLastName.textContent = s.lastName;

            const thFacNum = document.createElement('th');
            thFacNum.textContent = s.facultyNumber;

            const thGrade = document.createElement('th');
            thGrade.textContent = s.grade;

            tr.appendChild(thFirstName);
            tr.appendChild(thLastName);
            tr.appendChild(thFacNum);
            tr.appendChild(thGrade);

            tbody.appendChild(tr);
        });
    }

    function CreateStudent(e) {
        e.preventDefault();
        const form = e.target;
        const formData = new FormData(form);

        const firstName = formData.get('firstName');
        const lastName = formData.get('lastName');
        const facultyNumber = formData.get('facultyNumber');
        const grade = formData.get('grade');

        if (firstName === '' ||
            lastName === '' ||
            facultyNumber === '' ||
            grade === '') {
                document.querySelector('.notification').textContent = 'Error';
        }else{
            Create(firstName, lastName, facultyNumber, grade);
        }

    }



    async function GetAllStudent() {
        const url = "http://localhost:3030/jsonstore/collections/students";

        const response = await fetch(url);
        const data = await response.json();

        LoadStudents(Object.values(data));
    }

    async function Create(firstName, lastName, facultyNumber, grade) {
        const url = "http://localhost:3030/jsonstore/collections/students";

        const body = {
            firstName,
            lastName,
            facultyNumber,
            grade
        }

        const header = CreateHeader('post', body);

        const response = await fetch(url, header);
        const data = await response.json();

        GetAllStudent();
    }

    function CreateHeader(method, body) {
        return {
            method: method,
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(body)
        }
    }