# cap-tryout

A simple application trying out the [dotnetcore/CAP library](https://github.com/dotnetcore/CAP).

## Getting started

### Run everything

- `docker-compose up -d`
- Run `CapTryout.Api`
- Run `CapTryout.Consumer`

### Add some food

Change `name` and `rating` to the food you like (or dislike) and make some requests. This step already uses CAP.

```bash
curl -X 'POST' \
  'https://localhost:7064/Meal' \
  -H 'accept: */*' \
  -H 'Content-Type: application/json' \
  -d '{
  "name": "Pizza",
  "rating": 10
}'
```

### Fetch data

You will be able to fetch everything you added (after it's been inserted by the consumer).

```bash
curl -X 'GET' \
  'https://localhost:7064/Meal' \
  -H 'accept: */*'
```
