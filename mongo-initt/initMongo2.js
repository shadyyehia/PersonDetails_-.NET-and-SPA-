db = db.getSiblingDB("PersonDetailsDb"); // Use or create the database

// Insert initial data into the "Persons" collection
db.PersonsColl.insertMany([
    {
        "name": "Ahmed Mohammed",
        "telephone Number": "20-010334445",
        "address": "10 Road Street",
        "country": "Egypt"
    },
    {
        "name": "Mona Mahmoud",
        "telephone Number": "20-010334445",
        "address": "11 Road Street",
        "country": "Egypt"
    },
    {
        "name": "Mohammed Rabie",
        "telephone Number": "970-111111111",
        "address": "15 Road Street",
        "country": "Palestine"
    },
    {
        "name": "Ana yousif",
        "telephone Number": "961-111111111",
        "address": "20 Road Street",
        "country": "Lebanon"
    }
]);