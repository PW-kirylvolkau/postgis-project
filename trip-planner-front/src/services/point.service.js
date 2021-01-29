import {getToken, deleteToken} from './token.service';
import config from '../appconfig.json';

export async function addPointToTrip(tripId, payload) {
    return await fetch(`${config.api.baseURL+config.api.pointURN}?tripId=${tripId}`, {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json',
            'Authorization': 'Bearer '+ getToken(),
        },
        body: JSON.stringify(payload)
    })
        .then(async response => {
            switch (response.status) {
                case 401:
                    deleteToken();
                    window.location.reload(false);
                    break;
                case 200:
                case 201:
                    const point = await response.json();
                    return {
                        type: 'success',
                        point
                    };
                case 404:
                    return {type: 'error', message: 'Wrong trip.' }
                default:
                    return {type: 'error', message: 'unknown'}
            }
        })
        .catch();
}
