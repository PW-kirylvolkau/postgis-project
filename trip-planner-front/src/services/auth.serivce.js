import {saveToken} from './token.service';
import Config from '../appconfig.json';

export async function loginUser(credentials) {
    return fetch(Config.api.baseURL + Config.api.loginURN, {
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
