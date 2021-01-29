import React, {useEffect, useState} from 'react';
import {MapContainer, Marker, Popup, TileLayer} from "react-leaflet";
import {getToken} from "../../services/token.service";

function NewTripMap({ markers }) {
    const json = [
        {
            "name": "Грицевец С. И.",
            "wikiLink": "https://be.wikipedia.org/wiki/%D0%9F%D0%BE%D0%BC%D0%BD%D1%96%D0%BA%20%D0%A1%D1%8F%D1%80%D0%B3%D0%B5%D1%8E%20%D0%86%D0%B2%D0%B0%D0%BD%D0%B0%D0%B2%D1%96%D1%87%D1%83%20%D0%93%D1%80%D1%8B%D1%86%D0%B0%D1%9E%D1%86%D1%83%20%28%D0%9C%D1%96%D0%BD%D1%81%D0%BA%29",
            "imageLink": "https://commons.wikimedia.org/wiki/File:%D0%92%D1%83%D0%BB._%D0%9B%D0%B5%D0%BD%D1%96%D0%BD%D0%B0_%28%D0%9F%D0%BE%D0%BC%D0%BD%D1%96%D0%BA_%D0%93%D1%80%D1%8B%D1%86%D0%B0%D1%9E%D1%86%D1%83%29.JPG"
        },
        {
            "name": "National Bank",
            "wikiLink": "https://en.wikipedia.org/wiki/National%20Bank%20of%20the%20Republic%20of%20Belarus",
            "imageLink": "https://commons.wikimedia.org/wiki/File:National_Bank_of_Belarus_%282019%29.jpg"
        },
        {
            "name": "Дзяржаўны ўніверсальны магазін, Мінск",
            "wikiLink": "https://be.wikipedia.org/wiki/%D0%94%D0%B7%D1%8F%D1%80%D0%B6%D0%B0%D1%9E%D0%BD%D1%8B%20%D1%9E%D0%BD%D1%96%D0%B2%D0%B5%D1%80%D1%81%D0%B0%D0%BB%D1%8C%D0%BD%D1%8B%20%D0%BC%D0%B0%D0%B3%D0%B0%D0%B7%D1%96%D0%BD%20%28%D0%9C%D1%96%D0%BD%D1%81%D0%BA%29",
            "imageLink": "https://commons.wikimedia.org/wiki/File:Independence-Lenin_Minsk_2.jpg"
        },
        {
            "name": "Рака памяці",
            "wikiLink": "https://be.wikipedia.org/wiki/%D0%A0%D0%B0%D0%BA%D0%B0%20%D0%BF%D0%B0%D0%BC%D1%8F%D1%86%D1%96",
            "imageLink": null
        },
        {
            "name": "Анри Дюнан",
            "wikiLink": "https://be.wikipedia.org/wiki/%D0%9F%D0%BE%D0%BC%D0%BD%D1%96%D0%BA%20%D0%90%D0%BD%D1%80%D1%8B%20%D0%94%D0%B7%D1%8E%D0%BD%D0%B0%D0%BD%D1%83%20%28%D0%9C%D1%96%D0%BD%D1%81%D0%BA%29",
            "imageLink": "https://commons.wikimedia.org/wiki/File:%D0%9C%D1%96%D0%BD%D1%81%D0%BA._%D0%91%D1%83%D0%BB%D1%8C%D0%B2%D0%B0%D1%80_%D0%BF%D0%B0_%D0%B2%D1%83%D0%BB._%D0%9B%D0%B5%D0%BD%D1%96%D0%BD%D0%B0_%D0%B7_%D0%BF%D0%BE%D0%BC%D0%BD%D1%96%D0%BA%D0%B0%D0%BC_%D0%94%D0%B7%D1%8E%D0%BD%D0%B0%D0%BD%D1%83_%2802%29.jpg"
        }
    ];
    const [recommendations, setRecommendations] = useState([]);

    useEffect(() => {
        let arr = [];
        markers?.map((val) => {
            fetch(`https://localhost:5001/api/services/map-data?lat=${val.lat}&lng=${val.lng}`, {
                method: 'GET',
                headers: {
                    'Content-Type': 'application/json',
                    'Authorization': 'Bearer '+ getToken(),
                }
            })
                .then(data => data.json())
                .then(data => {
                    arr.push(data);
                })
                .catch(alert);
        })
        setRecommendations([...arr]);


    }, [markers])

    return (
        <div className="card m-3">
                <MapContainer style={{height: "400px"}} center={[51.505, -0.09]} zoom={13} scrollWheelZoom={false}>
                    <TileLayer
                        attribution='&copy; <a href="http://osm.org/copyright">OpenStreetMap</a> contributors'
                        url="https://{s}.tile.openstreetmap.org/{z}/{x}/{y}.png"
                    />
                    {
                        markers?.map((val, index) => {
                            return (
                                <div key={index}>
                            <Marker position={[val.lat, val.lng]}>
                                <Popup>
                                    <b>{val.address}</b>
                                    <button>{json[0].name}</button>
                                    <p>{json[0].wikiLink}</p>
                                    <button>{json[1].name}</button>
                                    <p>{json[1].wikiLink}</p>
                                </Popup>
                            </Marker>
                                </div>
                            )
                        })
                    }
                </MapContainer>
        </div>

    )
}

export default NewTripMap;
