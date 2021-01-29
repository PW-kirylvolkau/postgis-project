import React, {useEffect, useState} from 'react';
import ReactMarkdown from 'react-markdown';
import Config from '../../appconfig.json';

function FirstPage() {
    const [md, setMD] = useState();

    useEffect(() => {
        fetch(Config.external.github)
            .then(data => data.text())
            .then(text => setMD(text));
    });

    return(
        <div className="card m-3">
            <div className="card-body">
                <ReactMarkdown source={md} />
            </div>
        </div>
    )
}

export default FirstPage;
