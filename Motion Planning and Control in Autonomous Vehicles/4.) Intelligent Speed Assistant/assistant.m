% 1. Parametrelerin Tanımlanması
s = 0:1:3000;  % yol boyunca konumlar
ay_comfort = 2;  % konforlu yanal ivme
ax_comfort = 1.5;  % konforlu yavaşlama (örnek değer)

% Eğrilik bilgisi
kappa = zeros(size(s));
kappa(s > 400 & s <= 1000) = 0.005;
kappa(s > 1800 & s <= 2400) = 0.0025;

% Trafik hız limiti
vlim_traffic = zeros(size(s));
vlim_traffic(s <= 400) = 90;
vlim_traffic(s > 400 & s <= 1000) = 50;
vlim_traffic(s > 1000 & s <= 1800) = 70;
vlim_traffic(s > 1800 & s <= 2400) = 50;
vlim_traffic(s > 2400) = 90;

% 2.Yol eğriliğine göre hız limiti
vlim_road = zeros(size(s));
for i = 1:length(s)
    if kappa(i) ~= 0
        vlim_road(i) = sqrt(ay_comfort / kappa(i));
    else
        vlim_road(i) = inf;  % eğrilik yoksa sınırsız
    end
end

% 3. Gerçek hız limiti (min alınır)
vlim = min(vlim_road, vlim_traffic);

% 4. Yavaşlamaya Başlama Mesafesi (dtrig)
v_curr = 25;  % mevcut hız [m/s]
v_target = 13.8;  % yeni hız limiti [m/s]

d_trig = (v_curr^2 - v_target^2) / (2 * ax_comfort);
fprintf('Yavaşlamaya başlanacak mesafe: %.2f metre\n', d_trig);

% 5. Grafik Çizdir (Hız Limitleri ve Eğrilik)
figure;

subplot(3,1,1)
plot(s, kappa); title('Yol Eğriliği κ'); xlabel('Mesafe [m]'); ylabel('\kappa');

subplot(3,1,2)
plot(s, vlim_road); title('Yola göre hız limiti (v_{lim,road})'); ylabel('v [m/s]');

subplot(3,1,3)
plot(s, vlim); title('Son hız limiti (min trafik/yol)'); ylabel('v_{lim} [m/s]'); xlabel('Mesafe [m]');
