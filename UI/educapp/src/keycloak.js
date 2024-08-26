import Keycloak from 'keycloak-js';

const initOptions = {
  url: 'http://localhost:8090',
  realm: 'educapp',
  clientId: 'educappclient'
};

// Create Keycloak instance
const keycloak = new Keycloak(initOptions);

// Initialize Keycloak instance
const initKeycloak = () =>
  new Promise((resolve, reject) => {
    keycloak.init({
      onLoad: 'login-required',
      checkLoginIframe: true,
      pkceMethod: 'S256'
    }).then((auth) => {
      if (!auth) {
        window.location.reload();
      } else {
        resolve(keycloak);
      }
    }).catch((error) => {
      reject(error);
    });
  });

export { keycloak, initKeycloak };
