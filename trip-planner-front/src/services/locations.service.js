import {getToken} from './token.service';
import config from '../appconfig.json';

export async function getAutocompleteLocation(search) {
    return await fetch(`${config.api.baseURL + 
    config.api.services.serviceURN + 
    config.api.services.geoapifyAutocomplete}?address=${search}`, {
        method: 'GET',
        headers: {
            'Content-Type': 'application/json',
            'Authorization': 'Bearer '+ getToken(),
        }
    })
        .then(data => data.json())
        .catch(e => alert(e));
}
