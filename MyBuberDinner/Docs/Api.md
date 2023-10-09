# My Buber Dinner API

- [My Buber Dinner Api](#buber-dinner-api)
  - [Auth](#auth)
    - [Register](#register)
      -[Register Request](#register-request)
      -[Register Response](#register-response)
    - [Login](#login)
      - [Login Request](#login-request)  
      - [Login Response](#login-response)

## Auth

### Register

```js
POST {{host}}/auth/register
```

#### Register Request

```json
{
    "firstName":"Tom",
    "lastName":"Mooch",
    "email":"TomMooch@email.com",
    "password":"Passw0rd!"
}
```

#### Register Response

```js
200 Ok
```

```json
{
    "id":"d89...-...-...-...194",
    "firstName":"Tom",
    "lastName":"Mooch",
    "email":"TomMooch@email.com",
    "token":"eyjhb...x0y"
}
```


### Login

```js
POST {{host}}/auth/login
```

#### Login Request

```json
{
    "email":"TomMooch@email.com",
    "password":"Passw0rd!"
}
```

#### Login Response

```js
200 OK
```

```json
{
    "id":"d89...-...-...-...194",
    "firstName":"Tom",
    "lastName":"Mooch",
    "email":"TomMooch@email.com",
    "token":"eyjhb...x0y"
}
```