const tokenKey = 'OnlineTestSystemAccessToken';

function saveToken(token) {
  localStorage.setItem(tokenKey, token);
}

function getToken() {
  return localStorage.getItem(tokenKey);
}

function removeToken(){
  localStorage.setItem(tokenKey, null);
}

function getUserFromToken(token) {
  const data = token.split('.')[1];
  const payload = JSON.parse(atob(data));
  if (payload) {
    return {
      username: payload.sub,
    };
  }
  return null;
}

export {
  saveToken,
  getToken,
  removeToken,
  getUserFromToken
};