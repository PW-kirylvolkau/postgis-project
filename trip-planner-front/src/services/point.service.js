import {getToken, deleteToken} from './token.service';
import config from '../appconfig.json';
import {logoutUser} from "./auth.serivce";

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
                    //const point = response.json();
                    return {
                        type: 'success'
                        //point
                    };
                case 404:
                    return {type: 'error', message: 'Wrong trip.' }
                default:
                    return {type: 'error', message: 'unknown'}
            }
        })
        .catch();
}

export async function getAllPointsForTrip(tripId) {
    return await fetch(config.api.baseURL+config.api.tripURN+tripId+"/points", {
        method: 'GET',
        headers: {
            'Content-Type': 'application/json',
            'Authorization': 'Bearer '+ getToken(),
        }
    }).then(data => {
        switch (data.status) {
            case 401:
                logoutUser();
                return;
            case 200:
                return data.json();
            case 404:
                return null;
            default:
                throw("Some strange error occured at data displaying");
        }
    }).catch();
}
