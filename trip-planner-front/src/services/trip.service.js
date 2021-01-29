import {getToken, deleteToken} from './token.service';
import Config from '../appconfig.json';

export async function createTrip(payload) {
    return await fetch(Config.api.baseURL + Config.api.tripURN, {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json',
                'Authorization': 'Bearer '+ getToken(),
            },
            body: JSON.stringify(payload)
        })
        .then(async data => {
            if(data.status === 200 || data.status === 201) {
                const json = await data.json();
                return json;
            }
            else if (data.status === 401) {
                deleteToken();
                window.location.reload(false);
                return;
            }
            else {
                return null;
            }
        })
}
