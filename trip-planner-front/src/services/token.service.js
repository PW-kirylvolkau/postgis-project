const getToken = () => {
    const tokenString = localStorage.getItem('token');
    const userToken = JSON.parse(tokenString);
    return userToken;
};

const saveToken = userToken => {
    localStorage.setItem('token', JSON.stringify(userToken));
};

const deleteToken = () => {
    localStorage.removeItem('token');
}

module.exports = {getToken, saveToken, deleteToken}
