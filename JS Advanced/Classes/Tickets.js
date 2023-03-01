function solve(data, criteria) {
    class Ticket {
        constructor(destination, price, status) {
            this.destination = destination;
            this.price = Number(price);
            this.status = status;
        }
    }
    let result = [];

    for (const ticketData of data) {
        const [name, price, status] = ticketData.split('|');
        let ticket = new Ticket(name, price, status);

        result.push(ticket);
    }

    if (criteria == 'price') {
        result.sort((a, b) => a[criteria] - b[criteria]);
    } else {
        result.sort((a, b) => a[criteria].localeCompare(b[criteria]));
    }

    return result;
}

console.log(solve(['Philadelphia|94.20|available',
        'New York City|95.99|available',
        'New York City|95.99|sold',
        'Boston|126.20|departed'
    ],
    'price'
))