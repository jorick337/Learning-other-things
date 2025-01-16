# ОСТАНАВЛИВАЕТ ВСЕ СУЩЕСТВУЮШИЕ POLYBAR ПРОЦЕССЫ
killall -q polybar

# ЖДЕМ ПОКА ПРОЦЕССЫ НЕ БУДУТ ОСТАНОВЛЕНЫ
while pgrep -u %UID -x polybar >/dev/null; do sleep 1; done

# ЗАПУСК POLYBAR 
polybar --config=/home/joricks/.config/polybar/config  example &

# ПОДТВЕРЖДЕНИЕ ЗАПУСКА POLYBAR
echo "Polybar launched..."
