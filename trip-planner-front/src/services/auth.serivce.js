import {saveToken} from './token.service';

export async function loginUser(credentials) {
    return fetch('https://localhost:5001/api/authenticate/login', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(credentials)
    })
        .then(async data => {
            try {
                let json = await data.json();
                let token = json.token;
                saveToken(token);
                return token;
            }
            catch (_) {
                let code = data.status;
                if(code === 401) {
                    return null;
                }
            }
        })
        .catch(_ => null);
}
