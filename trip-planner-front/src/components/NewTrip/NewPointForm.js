import React, {useState} from 'react';
import Autocomplete from 'react-autocomplete';
import {addPointToTrip} from '../../services/point.service';
import { getAutocompleteLocation } from '../../services/locations.service';

function NewPointForm({tripId}) {
    const [name, setName] = useState("");
    const [suggestions, setSuggestions] = useState([]);

    const getData = async (search) => {
        const data = await getAutocompleteLocation(search);
        setSuggestions(await data);
        return data;
    }

    return (
        <div className="card m-3">
            <div className="card-header">
                <h3>Add point</h3>
            </div>
            <div className="card-body">
                <Autocomplete
                    getItemValue={(item) => item.address}
                    items={[
                        ...suggestions
                    ]}
                    renderItem={(item, isHighlighted) =>
                        <div style={{ background: isHighlighted ? 'lightgray' : 'white' }}>
                            {item.label}
                        </div>
                    }
                    value={name}
                    onChange={(e) => {
                        getData(e.target.value);
                        setName(e.target.value);
                    }}
                    onSelect={(val) => setName(val)}
                />
            </div>
        </div>
    )
}

export default NewPointForm;
