import React, {useState} from 'react';
import {addPointToTrip} from '../../services/point.service';
import {getAutocompleteLocation} from '../../services/locations.service';

function NewPointForm({tripId, setUpdate}) {
    const [address, setAddress] = useState("");
    const [suggestions, setSuggestions] = useState([]);
    const [lat, setLat] = useState();
    const [lng, setLng] = useState();

    const getSetAutoCompletion = (value) => {
        if (value.length > 0) {
            getAutocompleteLocation(value)
                .then(res => setSuggestions(res))
                .catch(() => setSuggestions([]));
        }
    };

    const onSubmit = (e) => {
        e.preventDefault();
        const payload = {
            name: address,
            lat,
            lng
        }

        addPointToTrip(tripId, payload).then(()=> {

        });
        setAddress("");
        setLng(undefined);
        setLat(undefined);
        setUpdate(true);
    }

    return (
        <div className="container m-3">
            <form onSubmit={onSubmit}>
                <input
                    type="text"
                    className="form-control"
                    value={address}
                    onChange={(e) => {
                        setAddress(e.target.value);
                        getSetAutoCompletion(e.target.value);
                        setLat(undefined);
                        setLng(undefined);
                    }}
                />
                <div className="overflow-auto ml-1">
                    {suggestions.map((val, key) => {
                        return (
                            <div key={key}
                                 style={
                                     {
                                         zIndex: '2',
                                         position: 'sticky',
                                         border: '1px solid #c4c4c4',
                                         height: '25px',
                                         borderRadius: '5px'
                                     }
                                 }>
                                <p onClick={(e) => {
                                    e.preventDefault();
                                    setAddress(val.address);
                                    setSuggestions([]);
                                    setLat(val.coordinates.lat);
                                    setLng(val.coordinates.lng);
                                }}>{val.address}</p>
                            </div>
                        )
                    })}
                </div>
                <button type="submit"
                        className="btn btn-success my-1"
                >
                    Add point.
                </button>
            </form>
        </div>
    );
}

export default NewPointForm;
