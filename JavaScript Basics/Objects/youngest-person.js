function solve(args) {
    function createPerson(properties) {
        return {
            'firstName': properties[0],
            'lastName': properties[1],
            'age': +properties[2]
        };
    }

    function getMinAge(people) {
        var minAge = Number.MAX_VALUE,
            i;
        for (i = 0; i < people.length; i += 1) {
            if (people[i].age < minAge) {
                minAge = people[i].age;
            }
        }

        return minAge;
    }

    var people = [],
        minAge,
        i;
    for (i = 0; i <= args.length - 3; i += 3) {
        people.push(createPerson([args[i], args[i + 1], args[i + 2]]));
    }

    minAge = getMinAge(people);
    for (i = 0; i <= people.length; i += 1) {
        if (minAge === people[i].age) {
            return people[i].firstName + ' ' + people[i].lastName;
        }
    }
}

console.log(solve([
    'Gosho', 'Petrov', '32',
    'Bay', 'Ivan', '81',
    'John', 'Doe', '42'
]));